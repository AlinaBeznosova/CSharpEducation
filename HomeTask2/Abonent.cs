namespace HomeTask3
{
	/// <summary>
	/// Абонент.
	/// </summary>
	class Abonent
	{
		#region Поля и свойства

		/// <summary>
		/// Имя абонента.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номер телефона абонента.
		/// </summary>
		public string PhoneNumber { get; set; }

		#endregion

		#region Конструктор

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="name">Имя абонента.</param>
		/// <param name="phoneNumber">Номер телефона абонента.</param>
		public Abonent(string name, string phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;

		}

		#endregion
	}
}
