namespace GymManager
{
    public class MenuTickets : MenuCommonLibrary
    {
        public MenuTickets()
            {
            _positions.Add(1,"Karnet jednorazowy");
            _positions.Add(2,"Karnet tygodniowy" );
            _positions.Add(3,"Karnet miesięczny");
            _positions.Add(4,"Karnet 3-miesięczny" );
            _positions.Add(5,"Wróć do poprzedniego menu" );
            _positions.Add(6,"Wyjście z programu" );
            }
    }

}