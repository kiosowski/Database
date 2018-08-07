namespace Banicharnica.App.Core.Contracts
{
    using Banicharnica.App.Core.Dtos;

    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}
