import { Component, OnInit } from '@angular/core';
import { IDemand } from '../model';
import { NavigationService } from '../services/navigation.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-demand',
  templateUrl: './demand.component.html',
  styleUrls: ['./demand.component.css'],
})
export class DemandComponent implements OnInit {
  dataForm!: FormGroup;

  // ******************************************
  view: 'demand' = 'demand';
  edit = faEdit;
  delete = faTrash;
  demands: IDemand[] = [];
  demand: IDemand = {
    demandId: 0,
    demandName: '',
    email: '',
    accountName: '',
    manager: '',
    openPosition: 0,
    experience: '',
    maxBudget: 0,
    noticePeriod: 0,
    employeeType: '',
    status: '',
    skills: '',
    location: '',
  };

  constructor(
    private navigationService: NavigationService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.dataForm = this.fb.group({
      DemandName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      Account_Name: [''],
      Manager: [''],
      OpenPosition: [''],
      Experience: [''],
      MaxBudget: [''],
      NoticePeriod: [''],
      EmployeeType: [''],
      Status: [''],
      Skills: [''],
      Location: [''],
    });
    this.navigationService.GetAllDemand().subscribe((res: any) => {
      this.demands = res;
    });
  }
  DeleteDemand(demand: IDemand) {
    this.navigationService.DeleteDemand(demand).subscribe((res: any) => {
      this.demand = res;
    });
  }
  CreateDemand(demand: IDemand) {
    this.navigationService.CreateDemand(demand).subscribe((res: any) => {
      this.demand = res;
    });
  }
  isEdit(demand: IDemand) {
    this.demand = demand;
  }
  UpdateDemand(demand: IDemand) {
    this.navigationService.UpdateDemand(demand).subscribe((res: any) => {
      this.demand = res;
    });
  }
}
