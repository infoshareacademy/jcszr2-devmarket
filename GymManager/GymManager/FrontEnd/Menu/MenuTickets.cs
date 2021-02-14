namespace GymManager
{
    public class MenuTickets : MenuCommonLibrary
    {
        public MenuTickets()
            {
            _positions.Add("Karnet jednorazowy",1);
            _positions.Add("Karnet tygodniowy",2);
            _positions.Add("Karnet miesięczny",3);
            _positions.Add("Karnet 3-miesięczny",4);
            _positions.Add("Wróć do poprzedniego menu",5);
            _positions.Add("Wyjście z programu",6);
            }
    }

}