using Server.DataContracts;

namespace Server.Service.ControlBlocks
{
    public interface ITeamEventConnector
    {
        void CreateTeamEvent(int teamID, Event addedEvent);
    }
}
