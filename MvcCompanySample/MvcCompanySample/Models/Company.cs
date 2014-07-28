using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcCompanySample.Models
{
    public class Company
    {
        //Identifier  
        public int CompanyId { get; set; }
        //Company 
        public string Company_name { get; set; }
        public string Address { get; set; }
        public string Postal_Code { get; set; }
        public string City { get; set; }
        // State 
        public int StateId { get; set; }
        public virtual State State { get; set; }
        //Country  
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        //Communication 
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website_Uri { get; set; }
        //List Contacts 
        public virtual List<Contact> Contacts { get; set; }
        //List Documents 
        public virtual List<Document> Documents { get; set; }
    }

    public class Contact
    {
        //Identifier 
        public int ContactId { get; set; }
        //Company  
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //Function 
        public int FunctionId { get; set; }
        public virtual Function Function { get; set; }
        //Title 
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }
        //Contact 
        public string Surname { get; set; }
        public string Last_name { get; set; }
        //Communication 
        public string Email_address { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
    }
    public class Costs_group
    {
        //Identifier 
        public int Costs_groupId { get; set; }
        //Costs group 
        public string Cost_group_name { get; set; }
    }
    public class Country
    {
        //Identifier  
        public int CountryId { get; set; }
        //Country 
        public string Country_name { get; set; }
    }
    public class Document
    {
        //Identifier 
        public int DocumentId { get; set; }
        [Required]
        //Document date 
        public DateTime Document_date { get; set; }
        //Company 
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //Mail category 
        public int Mail_categoryID { get; set; }
        public virtual Mail_category Mail_category { get; set; }
        //Costs group 
        public int Costs_groupId { get; set; }
        public virtual Costs_group Costs_group { get; set; }
        //Payment status 
        public int Payment_statusId { get; set; }
        public virtual Payment_status Payment_status { get; set; }
        [Required]

        //Bill 
        public string Reference { get; set; }
        //Note 
        [Required]
        public string Note { get; set; }
        //Financial 
        [Required]
        public double AmoutExVat { get; set; }
        [Required]
        public double Vat { get; set; }
        [Required]
        public double Amount { get; set; }
        //.PDF Link 
        [Required]
        public string Document_uri { get; set; }
    }
    public class State
    {
        //Identifier 
        public int StateId { get; set; }
        //State 
        public string State_name { get; set; }
    }

    public class Function
    {
        //Identifier 
        public int FunctionId { get; set; }
        //Function 
        public string Function_name { get; set; }
    }
    public class Mail_category
    {
        //Identifier 
        public int Mail_categoryId { get; set; }
        //Mail category 
        public string Mail_category_name { get; set; }
    }
    public class Payment_status
    {
        //Identifier 
        public int Payment_statusId { get; set; }
        //Payment status 
        public string Payment_status_name { get; set; }
    }
    public class Title
    {
        //Identifier 
        public int TitleId { get; set; }
        //Title 
        public string Title_name { get; set; }
    }


}