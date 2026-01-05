namespace SistemInformaticPensiune.Models
{
    public class FacilitateCamera
    {
        public int ID { get; set; }
        public int CameraID { get; set; }
        public Camera Camera { get; set; }
        public int FacilitateID { get; set; }
        public Facilitate Facilitate { get; set; }
    }
}
