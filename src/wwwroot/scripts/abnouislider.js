window.sliders = [];

window.renderSlider = function (configuration, dotNetObjectReference) {
    let slider = document.getElementById('slider');
    noUiSlider.create(slider, configuration);
    slider.noUiSlider.on("slide", function (val)
    {
        dotNetObjectReference.invokeMethodAsync("valueChanged", Number(val[0]));
    });
    window.sliders.push({ slider, configuration, dotNetObjectReference });
}

window.updateSlider = function (configuration) {
    window.sliders.forEach((value, index) => {
        if (value.configuration.id === configuration.id) {
            configuration.start = value.slider.noUiSlider.get();
            value.slider.noUiSlider.updateOptions(configuration);
            value.configuration = configuration;
        }
    });
}