using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_API;
namespace Testing.Mock
{
    static class UserMock
    {
        public static User AddValidUser()
        {
            return new User
            {
                
                    UserId= 1,
                    Name= "pooja",
                    Email= "pooja12@gmail.com",
                    UserName= "pooja.sakthivel",
                    Password= "Pooja@123",
                    CountryCodeId= 1,
                    
                    MobileNumber= "9876567898",
                    DesignationId= 1,
                    
                    ReportingPersonUsername= "Jaya",
                    OrganisationId=1,
                    
                    GenderId= 2,
                    
                    CreatedBy= 3,
                    CreatedOn= null,
                    UpdatedBy=3,
                    UpdatedOn= null,
                    IsActive= true

            };
        }
        // public static User GetValidUser()
        // {
        //     return new User{
        //             UserId= 1,
        //             Name= "Pavithra",
        //             Email= "pa12@gmail.com",
        //             UserName="Pavithra.kavin",
        //             Password= "pavithrak@123",
        //             GenderId= 2,
        //             CountryCodeId= 1,
        //             MobileNumber= "9876567890",
        //             DesignationId= 1,
        //             ReportingPersonUsername= "Jaya.Ethiraj",
        //             OrganisationId= 1
        //     };
        // }
        public static List<User> GetValidateAllUsers()
        {
            return new List<User>()
            {
               new User(){UserId= 1,
                    Name= "pooja",
                    Email= "pooja12@gmail.com",
                    UserName= "pooja.sakthivel",
                    Password= "Pooja@123",
                    CountryCodeId= 1,
                    
                    MobileNumber= "9876567898",
                    DesignationId= 1,
                    
                    ReportingPersonUsername= "Jaya",
                    OrganisationId=1,
                    
                    GenderId= 2,
                    
                    CreatedBy= 3,
                    CreatedOn= null,
                    UpdatedBy=3,
                    UpdatedOn= null,
                    IsActive= true
                    },
                new User(){
                    UserId= 2,
                    Name= "Brindha",
                    Email= "brin2@gmail.com",
                    UserName= "brindha.muruga",
                    Password= "Brindha@123",
                    CountryCodeId= 1,
                    
                    MobileNumber= "987685434",
                    DesignationId= 1,
                    
                    ReportingPersonUsername= "Savitha",
                    OrganisationId=1,
                    
                    GenderId= 2,
                    
                    CreatedBy= 3,
                    CreatedOn= null,
                    UpdatedBy=3,
                    UpdatedOn= null,
                    IsActive= true
                },
                new User(){
                    UserId= 3,
                    Name= "Yoga",
                    Email= "yoga12@gmail.com",
                    UserName= "yoga.govind",
                    Password= "Yoga@183",
                    CountryCodeId= 1,
                    
                    MobileNumber= "9786098765",
                    DesignationId= 2,
                    
                    ReportingPersonUsername= "Jaya",
                    OrganisationId=2,
                    
                    GenderId= 2,
                    
                    CreatedBy= 3,
                    CreatedOn= null,
                    UpdatedBy=3,
                    UpdatedOn= null,
                    IsActive= true

                }
            };

        }
        public static User UpdateValidUser()
        {
            return new User
            {
                
                    UserId= 1,
                    Name= "pooja",
                    Email= "pooja12@gmail.com",
                    UserName= "pooja.sakthivel",
                    Password= "Pooja@123",
                    CountryCodeId= 1,
                    
                    MobileNumber= "9876567898",
                    DesignationId= 1,
                    
                    ReportingPersonUsername= "Jaya",
                    OrganisationId=1,
                    
                    GenderId= 2,
                    
                    CreatedBy= 3,
                    CreatedOn= null,
                    UpdatedBy=3,
                    UpdatedOn= null,
                    IsActive= true

            };
        }
        
    }
}