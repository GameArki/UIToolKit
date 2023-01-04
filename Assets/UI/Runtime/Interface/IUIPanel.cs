namespace UIRenderer {

    internal interface IUIPanel {
        
        int ID { get; }
        int TypeID { get; }
        short Weight { get; }
        sbyte Root { get; }
        bool IsUnique { get; }

        void Close();

    }

}