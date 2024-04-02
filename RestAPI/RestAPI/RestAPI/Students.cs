namespace RestAPI
{
    public class Students
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public Students() { }
		public Students(int id, string name) 
		{ 
			this.id = id;
			this.name = name;
		}

	}
}
