using QuriWasi.Application.Rooms.Queries.ExportRoom;
using CsvHelper.Configuration;
using System.Globalization;

namespace QuriWasi.Infrastructure.Files.Maps
{
    public class RoomItemRecordMap : ClassMap<RoomItemRecord>
    {
        public RoomItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
