namespace MVC004.Models
{
    public class ObjView
    {
        public int Id { get; set; }
        public object objFromDataBase { get; set; }
        public object dataToSend { get; set; }

        public ObjView(object obj1, object obj2) {
            this.objFromDataBase = obj1;
            this.dataToSend = obj2;
        }

    }
}
