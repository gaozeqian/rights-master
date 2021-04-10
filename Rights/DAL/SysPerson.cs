//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Langben.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysPerson
    {
        public SysPerson()
        {
            this.SysDocument = new HashSet<SysDocument>();
            this.SysRole = new HashSet<SysRole>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string MyName { get; set; }
        public string Password { get; set; }
        public string SurePassword { get; set; }
        public string Sex { get; set; }
        public string SysDepartmentId { get; set; }
        public string Position { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Remark { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> LogonNum { get; set; }
        public Nullable<System.DateTime> LogonTime { get; set; }
        public string LogonIP { get; set; }
        public Nullable<System.DateTime> LastLogonTime { get; set; }
        public string LastLogonIP { get; set; }
        public string PageStyle { get; set; }
        public string UpdatePerson { get; set; }
        public byte[] Version { get; set; }
        public string HDpic { get; set; }
    
        public virtual SysDepartment SysDepartment { get; set; }
        public virtual ICollection<SysDocument> SysDocument { get; set; }
        public virtual ICollection<SysRole> SysRole { get; set; }
    }
}
