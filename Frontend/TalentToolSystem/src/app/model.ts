export interface ICandidate {
  candidateId: number;
  candidateName: string;
  email: string;
  mobile: string;
  currentCompany?: string | null;
  skillSet: string;
  yearOfExperience: number;
  location: string;
  ctc: number;
  ectc: number;
  noticePeriod: number;
  referralId: number;
  status: string;
  manager: string;
  account: string;
}

export interface IDemand {
  demandId: number;
  demandName: string;
  email: string;
  accountName: string;
  manager: string;
  openPosition: number;
  experience: string;
  maxBudget: number;
  noticePeriod: number;
  employeeType: string;
  status: string;
  skills: string;
  location: string;
}

export interface ILocation {
  locationId: number;
  city: string;
  state: string;
}
