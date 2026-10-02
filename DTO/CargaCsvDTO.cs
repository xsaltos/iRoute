namespace iRoute.DTO
{
    public class CargaCsvDTO
    {

            public string pcNomcomred { get; set; }

            public int pcnumdoc { get; set; }

            public string pcprocessdate { get; set; }
       
    }
    public class CsvRequest
    {
        public List<CargaCsvDTO> Data { get; set; }
    }
}
