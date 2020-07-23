namespace AMModel.Models {
    public interface IModel {
        int ID { get; set; }
        string TABLE_NAME { get; }
        void Select();
        void Delete();
        void Update();
        void Insert();
        int Count();
        bool Validate();
    }
}