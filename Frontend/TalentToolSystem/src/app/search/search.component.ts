import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { faEdit, faTrash, faEye, faFileCsv } from '@fortawesome/free-solid-svg-icons';
import * as XLSX from 'xlsx';
import  {SearchService} from './../services/search.service'; 


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  edit = faEdit;
  delete = faTrash;
  view = faEye;
  excel = faFileCsv;

  isCandidateSearch: boolean = true;
  candidateForm: any = {
    Account: '',
    CandidateName: '',
    Manager: '',
    Status: '',
    Location: '',
    ReferralId: null
  };
  demandForm: any = {
    Account: '',
    Demand: '',
    Manager: '',
    Status: '',
    Location: '',
    EmployeeType: '',
  };

  candidateDataArray: any[] = [];
  demandDataArray: any[] = [];
  formdataArray: any[] = [];
  response: string = "";

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private searchService: SearchService) {
    this.candidateForm = this.formBuilder.group({
      Account: [''],
      Manager: [''],
      CandidateName: [''],
      Location: [''],
      ReferralId: [null],
      Status: [''],
    });
    this.demandForm = this.formBuilder.group({
      Account: [''],
      Demand: [''],
      Manager: [''],
      Status: [''],
      Location: [''],
      EmployeeType: [''],
    });
  }

  toggleSearch() {
    this.formdataArray = []
    this.response = ""
    this.isCandidateSearch = !this.isCandidateSearch;
  }

  submitCandidateForm() {
    this.response = ""
    const queryParams: any = { ...this.candidateForm.value };

    for (const key in queryParams) {
      if (queryParams[key] === null || queryParams[key] === '') {
        delete queryParams[key];
      }
    }
    if (Object.keys(queryParams).length > 0) {
      this.searchService.searchCandidates(queryParams).subscribe((response) => {
        this.formdataArray = response;
      });
      this.NotFound()
    }else{
      this.response = "Enter the details for the Search"
    }
  }

  NotFound(){    
    if(this.formdataArray.length < 0) {
      if (this.isCandidateSearch) this.response = "No Candidates are found"
      else this.response = "No Demands are found"
    }
  }

  submitDemandForm() {
    this.response = ""
    const queryParams: any = { ...this.demandForm.value };
    for (const key in queryParams) {
      if (queryParams[key] === null || queryParams[key] === '') {
        delete queryParams[key];
      }
    }
    if (Object.keys(queryParams).length > 0) {
      this.searchService.searchDemands(queryParams).subscribe((response) => {
        this.formdataArray = response;
        console.log(this.formdataArray);
        
      });
      this.NotFound()
    }else{
      this.response = "Enter the details for the Search";
    }

  }

  exportToExcel() {
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.formdataArray);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'SearchResults');
    XLSX.writeFile(wb, 'search-results.xlsx');
  }

  clearForm() {
    if (this.isCandidateSearch) {
      this.candidateForm.reset();
    } else {
      this.demandForm.reset();
    }
    this.formdataArray = [];
    this.response = "";
  }
}
