namespace iRoute.DTO
{
    public class CargaCsvDTO
    {

            public string pc_nomcomred { get; set; }

            public int pc_numdoc { get; set; }

            public string pc_processdate { get; set; }
       
    }
    public class CsvRequest
    {
        public List<CargaCsvDTO> Data { get; set; }
    }
}
