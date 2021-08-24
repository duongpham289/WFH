class EmployeeModel {
    initData() {
        return  {
            EmployeeCode: "",
            FullName: "",
            DateOfBirth: null,
            Gender: 1,
            IdentityNumber: "",
            IdentityDate: null,
            IdentityPlace: "",
            Email: "",
            PhoneNumber: "",
            PersonalTaxCode: "",
            Salary: null,
            JoinDate: null,
            WorkStatus: null,
        }
    }
}
export default new EmployeeModel();