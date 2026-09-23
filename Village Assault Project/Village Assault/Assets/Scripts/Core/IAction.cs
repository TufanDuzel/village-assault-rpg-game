namespace RPG.Core
{
    // Defines an interface for actions in the game, allowing for various implementations.
    public interface IAction
    {
        // Method to cancel any ongoing actions.
        void Cancel();
    }
}