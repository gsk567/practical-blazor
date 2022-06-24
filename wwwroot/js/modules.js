export function initializeGlobalEventService(dotNetRef) {
    document.onkeydown = (evt) => {
        evt = evt || window.event;
        dotNetRef.invokeMethodAsync('OnGlobalKeyPressed', evt.code);
    };
}