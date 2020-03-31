import Company from "./Company";
import { Priority } from "./Priority";

export default interface Department {
  Id: string;
  Name: string;
  Company: Company;
  Priority: Priority;
}
