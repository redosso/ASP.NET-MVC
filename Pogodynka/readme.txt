Aplikacja z prognoz� pogody, oparta na serwisie: OpenWeatherMap
	

Po uruchomieniu aplikacja wczytuje list� prognoz, aby:

	1. Pobra� i zapisa� nale�y
		a) ZArejestrowea� si� na konto admina - link Admin
		b) B�d�c zalogowanym na koncie admin nale�y wybra� link na stronie "Dodaj prognoz�"
		c) Aplikacja pobiera dane JSON i prezentuje w edytowalnych polach
		d) Zapisujemy kolejny wynik pogody.

Po wylogowaniu mo�emy przej�� do listy zapisanych w bazie SQL prognoz.

WebAPI serwis proponuje o wiele wi�cej danych np. temp. min i max, ze wzgl�du na projekt
do�wiadczalny aplikacja wybiera kilka parametr�w oraz pobiera prognoz� 
dla miasta Warszawy, kt�r� mo�na przed zapisaniem edytowa�.