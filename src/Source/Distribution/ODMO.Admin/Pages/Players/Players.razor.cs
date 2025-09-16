using AutoMapper;
using ODMO.Admin.Shared;
using ODMO.Application.Admin.Queries;
using ODMO.Commons.Enums.Admin;
using ODMO.Commons.ViewModel.Maps;
using ODMO.Commons.ViewModel.Players;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODMO.Admin.Pages.Players
{
    public partial class Players
    {
        [Inject]
        public ISender Sender { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }

        private MudTextField<string> _filterParameter;
        private MudTable<PlayerViewModel> _table;

        private async Task<TableData<PlayerViewModel>> ServerReload(TableState state)
        {
            var players = await Sender.Send(
                new GetPlayersQuery(
                    state.Page,
                    state.PageSize,
                    state.SortLabel,
                    (SortDirectionEnum)state.SortDirection.GetHashCode(),
                    _filterParameter?.Value
                )
            );

            var pageData = Mapper.Map<IEnumerable<PlayerViewModel>>(players.Registers);

            return new TableData<PlayerViewModel>() { TotalItems = players.TotalRegisters, Items = pageData };
        }

        private async Task Filter()
        {
            await Refresh();
        }

        private async Task Clear()
        {
            _filterParameter.Clear();

            await Refresh();
        }

        private async Task Refresh()
        {
            await _table.ReloadServerData();
            await new Task(() => { _table.Loading = false; });
        }
    }
}
