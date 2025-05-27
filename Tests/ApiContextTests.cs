using Xunit;
using TestDesktop.Models;

namespace Tests
{
    public class ApiContextTests
    {
        private ApiContext _api;
        public ApiContextTests() => _api = new ApiContext();
        [Fact]
        public void GetEmployees_ShouldReturnList()
        {
            var result = _api.GetEmployees();
            Assert.NotNull(result);
            Assert.IsType<List<Employee>>(result);
        }
        [Fact]
        public void GetDepartaments_ShouldReturnList()
        {
            var result = _api.GetDepartaments();
            Assert.NotNull(result);
            Assert.IsType<List<Departament>>(result);
        }
        [Fact]
        public void GetPositions_ShouldReturnList()
        {
            var result = _api.GetPositions();
            Assert.NotNull(result);
            Assert.IsType<List<Position>>(result);
        }
        [Fact]
        public void GetOrganizations_ShouldReturnList()
        {
            var result = _api.GetOrganizations();
            Assert.NotNull(result);
            Assert.IsType<List<Organization>>(result);
        }
        [Fact]
        public void GetAbsences_ShouldReturnList()
        {
            var result = _api.GetAbsences();
            Assert.NotNull(result);
            Assert.IsType<List<Absences>>(result);
        }
    }
}