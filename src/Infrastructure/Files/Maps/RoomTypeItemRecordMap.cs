using QuriWasi.Application.RoomsType.Queries.ExportRoomType;
using CsvHelper.Configuration;
using System.Globalization;

namespace QuriWasi.Infrastructure.Files.Maps
{
    public class RoomTypeItemRecordMap : ClassMap<RoomTypeItemRecord>
    {
        public RoomTypeItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
