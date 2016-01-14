namespace App0
{
    public interface IDatabaseRepository
    {
        ApplicationDatabase MyData { get; }

        void Load();
    }
}