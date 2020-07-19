namespace AMModel.Models {
    public interface IModel {
        int Id { get; set; }
        void Select();
        void Delete();
        void Update();
        void Insert();
        //object[] All();
        //object[] Search();

        bool Validate();
    }
}