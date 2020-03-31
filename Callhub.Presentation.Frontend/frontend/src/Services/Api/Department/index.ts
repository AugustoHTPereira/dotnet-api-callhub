import Department from "../../../Interfaces/Department";

export default class DepartmentService {
  constructor() {}

  getAll(companyId: string): Array<Department> {
    return new Array<Department>();
  };
}
