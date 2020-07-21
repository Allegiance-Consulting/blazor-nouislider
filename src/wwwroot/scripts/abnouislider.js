window.sliders = [];

window.renderSlider = function (configuration, dotNetObjectReference) {
    console.log(configuration);
    let slider = document.getElementById(configuration.id);
    noUiSlider.create(slider, configuration);
    slider.noUiSlider.on("slide", function (val)
    {
        if (val.length === 1) {
            dotNetObjectReference.invokeMethodAsync("sliderValueChanged", Number(val[0]));
        }
        else {
            dotNetObjectReference.invokeMethodAsync("sliderValueChanged", Number(val[0]), Number(val[1]));
        }
    });
    window.sliders.push({ slider, configuration, dotNetObjectReference });
}

window.updateSlider = function (configuration) {
    window.sliders.forEach((value, index) => {
        if (value.configuration.id === configuration.id) {
            if (!configuration.setSlider) {
                configuration.start = value.slider.noUiSlider.get();
            } 
            value.slider.noUiSlider.updateOptions(configuration);
            value.configuration = configuration;
        }
    });
}