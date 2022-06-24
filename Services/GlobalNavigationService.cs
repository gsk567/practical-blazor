using Essentials.Extensions;
using Microsoft.AspNetCore.Components;
using PracticalBlazor.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalBlazor.Services
{
    public class GlobalNavigationService : IGlobalNavigationService
    {
        private readonly string[] nextKeys = new string[]
        {
            "ArrowRight",
            "Space"
        };

        private readonly string[] previousKeys = new string[]
        {
            "ArrowLeft"
        };

        private readonly IList<string> slides;
        private readonly NavigationManager navigationManager;
        private readonly IGlobalDomEventService globalDomEventService;

        public GlobalNavigationService(
            NavigationManager navigationManager,
            IGlobalDomEventService globalDomEventService)
        {
            this.navigationManager = navigationManager;
            this.globalDomEventService = globalDomEventService;
            this.globalDomEventService.GlobalKeyCodePressed += HandleGlobalKeyPress;

            this.slides = new List<string>();
            foreach (var slideType in SlidesSchema.OrderedSlidesTypes)
            {
                this.slides.Add(this.navigationManager.ToAbsoluteUri(GetSlideRoute(slideType)).ToString());
            }
        }

        public bool IsCurrentSlideTheFirst() => GetCurrentSlideIndex() == 0;

        public bool IsCurrentSlideTheLast() => GetCurrentSlideIndex() == this.slides.Count - 1;

        public void GoToNextSlide()
        {
            var currentIndex = GetCurrentSlideIndex();
            if (!IsCurrentSlideTheLast())
            {
                this.navigationManager.NavigateTo(this.slides.ElementAt(currentIndex + 1));
            }
        }

        public void GoToPreviousSlide()
        {
            var currentIndex = GetCurrentSlideIndex();
            if (!IsCurrentSlideTheFirst())
            {
                this.navigationManager.NavigateTo(this.slides.ElementAt(currentIndex - 1));
            }
        }

        private void HandleGlobalKeyPress(object sender, GlobalKeyCodePressedEventArgs args)
        {
            var currentIndex = GetCurrentSlideIndex();
            if (currentIndex < (this.slides.Count - 1) && this.nextKeys.Contains(args.KeyCode))
            {
                this.navigationManager.NavigateTo(this.slides.ElementAt(currentIndex + 1));
            }
            else if (currentIndex > 0 && this.previousKeys.Contains(args.KeyCode))
            {
                this.navigationManager.NavigateTo(this.slides.ElementAt(currentIndex - 1));
            }
        }

        public int GetCurrentSlideIndex()
        {
            var currentUrl = this.navigationManager.Uri;
            return this.slides.IndexOf(currentUrl);
        }

        private string GetSlideRoute(Type slidePageType) => slidePageType.GetAttribute<RouteAttribute>().Template;
    }
}
