using BottlesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public class PinService : IPinService
    {
        private IRepository _repository { get; }

        public PinService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PinModel>> GetAllPinsAsync()
        {
            await InitMockData();
            var pins = await _repository.GetAllAsync<PinModel>();
            return pins;
        }

        private async Task InitMockData()
        {
            var init1 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 0, Label = "home 1", Lng = 35.030957, Ltd = 48.426536 });
            var init2 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 1, Label = "home 2", Lng = 39.696796, Ltd = 47.246614 });
            var init3 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 2, Label = "just norway1!", Lng = 10.738740, Ltd = 59.913816 });
            var init4 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 3, Label = "just norway2!", Lng = 10.739640, Ltd = 59.920818 });
            var init5 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 4, Label = "just norway3!", Lng = 10.739640, Ltd = 59.915818 });
            var init6 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 5, Label = "just norway4!", Lng = 10.738640, Ltd = 59.914818 });
            var init7 = await _repository.SaveOrUpdateAsync(new PinModel { Id = 6, Label = "just norway5!", Lng = 10.739330, Ltd = 59.913918 });
        }
    }
}
