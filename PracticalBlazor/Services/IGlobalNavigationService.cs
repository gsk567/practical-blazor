namespace PracticalBlazor.Services;

public interface IGlobalNavigationService
{
    void GoToNextSlide();

    void GoToPreviousSlide();

    int GetCurrentSlideIndex();

    bool IsCurrentSlideTheFirst();

    bool IsCurrentSlideTheLast();
}