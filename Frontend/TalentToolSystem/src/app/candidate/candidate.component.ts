import { Component, OnInit } from '@angular/core';
import { ICandidate } from '../model';
import { NavigationService } from '../services/navigation.service';
import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
  ValidationErrors,
  AbstractControl,
} from '@angular/forms';

function mobileNumberValidator(
  control: AbstractControl
): ValidationErrors | null {
  const mobileNumber = control.value;
  const mobileNumberPattern = /^[0-9]{10}$/; // Please enter exactly 10 digits
  if (!mobileNumberPattern.test(mobileNumber)) {
    return { invalidMobileNumber: true };
  }

  return null;
}

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css'],
})
export class CandidateComponent implements OnInit {
  dataForm!: FormGroup;
  edit = faEdit;
  delete = faTrash;

  // ******************************************
  view: 'candidate' = 'candidate';
  candidates: ICandidate[] = [];
  candidate: ICandidate = {
    candidateId: 0,
    candidateName: '',
    email: '',
    mobile: '',
    currentCompany: '',
    skillSet: '',
    yearOfExperience: 0,
    location: '',
    ctc: 0,
    ectc: 0,
    noticePeriod: 0,
    referralId: 0,
    status: '',
    manager: 'Gunjan',
    account: 'Nexturn',
  };

  constructor(
    private navigationService: NavigationService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.dataForm = this.fb.group({
      CandidateName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      Mobile: ['', [Validators.required, mobileNumberValidator]],
      CurrentCompany: [''],
      SkillSets: [''],
      YearsOfExperience: [''],
      CTC: [''],
      ECTC: [''],
      MaxNoticePeriod: [''],
      Location: [''],
      EmployeeID: [''],
      Status: [''],
    });
    this.navigationService.GetAllCandidate().subscribe((res: any) => {
      console.log(res);
      this.candidates = res;
    });
  }
  DeleteCandidate(candidate: ICandidate) {
    this.navigationService.DeleteCandidate(candidate).subscribe((res: any) => {
      this.candidate = res;
    });
  }
  CreateCandidate(candidate: ICandidate) {
    this.navigationService.CreateCandidate(candidate).subscribe((res: any) => {
      this.candidate = res;
    });
    this.ngOnInit();
  }
  isEdit(candidate: ICandidate) {
    this.candidate = candidate;
  }
  UpdateCandidate(candidate: ICandidate) {
    this.navigationService.UpdateCandidate(candidate).subscribe((res: any) => {
      this.candidate = res;
    });
  }
}
