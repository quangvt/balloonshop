using System;

namespace BalloonShop.Domain.Entities
{
    public enum MemberState
    {
        Active,
        InActive,
        Unknown
    }

    public class Member
    {
        public Member()
        {
            Address = new Address();
        }
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Support Column: Not add this col to db
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set
            {
                var names = value.Split(new string[] { " " },
                    StringSplitOptions.RemoveEmptyEntries);
                FirstName = names[0];
                LastName = names[1];
            }
        }
        public MemberState MemberState { get; set; }
        // Complex Property
        public Address Address { get; set; }
    }
}
