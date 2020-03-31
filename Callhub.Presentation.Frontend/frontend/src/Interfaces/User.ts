import Department from "./Department";
import { Priority } from "./Priority";

export default interface User {
  Id: string,
  Name: string,
  Email: string,
  Password: string,
  CreatedAt: string,
  Department: Department,
  Priority: Priority
}