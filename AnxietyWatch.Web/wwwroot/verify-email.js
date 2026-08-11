(() => {
    let token = null;

    function captureToken() {
        const path = window.location.pathname.replace(/\/$/, "") || "/";
        if (path !== "/verify-email") {
            return;
        }

        const fragment = new URLSearchParams(window.location.hash.slice(1));
        token = fragment.get("token");

        if (window.location.hash) {
            window.history.replaceState(
                window.history.state,
                "",
                window.location.pathname + window.location.search);
        }
    }

    captureToken();

    window.anxietyWatchEmailVerification = Object.freeze({
        takeToken() {
            if (!token) {
                captureToken();
            }

            const capturedToken = token;
            token = null;
            return capturedToken;
        }
    });
})();
