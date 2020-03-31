import Company from "../../../Interfaces/Company";
import Api from "../";
import { AxiosRequestConfig, AxiosResponse } from "axios";

export default class CompanyService extends Api {
  constructor(config: AxiosRequestConfig) {
    super(config);
  }

  /**
   * @returns {Promise<Company[]>} All companies
   */
  getAll(): Promise<Company[]> {
    return this.get<Company[]>("/companies").then(
      (response: AxiosResponse<Company[]>) => {
        const companies:Company[] = response.data;

        return companies;
      }
    )
  }
}
