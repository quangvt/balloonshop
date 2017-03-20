namespace BalloonShop.Domain.Entities
{
    // Directly connect with View in DB
    //   => put to .Domain project
    public class DepartmentViewInfo
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
    }
}