Aplikacja z prognoz¹ pogody, oparta na serwisie: OpenWeatherMap
	

Po uruchomieniu aplikacja wczytuje listê prognoz, aby:

	1. Pobraæ i zapisaæ nale¿y
		a) ZArejestroweaæ siê na konto admina - link Admin
		b) Bêd¹c zalogowanym na koncie admin nale¿y wybraæ link na stronie "Dodaj prognozê"
		c) Aplikacja pobiera dane JSON i prezentuje w edytowalnych polach
		d) Zapisujemy kolejny wynik pogody.

Po wylogowaniu mo¿emy przejœæ do listy zapisanych w bazie SQL prognoz.

WebAPI serwis proponuje o wiele wiêcej danych np. temp. min i max, ze wzglêdu na projekt
doœwiadczalny aplikacja wybiera kilka parametrów oraz pobiera prognozê 
dla miasta Warszawy, któr¹ mo¿na przed zapisaniem edytowaæ.