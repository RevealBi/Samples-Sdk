// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class RobotoFontsLoader {
    _fontsLoaded = false;
    Load() {
        var loader = this;
        return new Promise((successHandler, errorHandler) => {
            if (loader._fontsLoaded) {
                successHandler();
            }
            try {
                WebFont.load({
                    custom: {
                        families: ['Roboto-Regular', 'Roboto-Bold', 'Roboto-Medium', 'Roboto-Light']
                    },
                    active: function () {
                        loader._fontsLoaded = true;
                        successHandler();
                    },
                    fontinactive: function(familyName, fvd) {
                        errorHandler(familyName + " failed to load")
                    }
                })
            } catch (error) {
                errorHandler(error)

            }
        });
    }
}

window.RobotoFontsLoader = new RobotoFontsLoader();
window.RobotoFontsLoader.Load();
