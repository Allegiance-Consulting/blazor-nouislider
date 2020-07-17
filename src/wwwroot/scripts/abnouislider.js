window.sliders = [];

window.renderSlider = function (configuration, dotNetObjectReference) {
    let slider = document.getElementById(configuration.id);
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
            if (!configuration.setSlider) {
                configuration.start = value.slider.noUiSlider.get();
            } 
            value.slider.noUiSlider.updateOptions(configuration);
            value.configuration = configuration;
        }
    });
}

window.mask = (id) => {
    var customMask = IMask(
        document.getElementById(id), {
        mask: "R num",
        blocks: {
            num: {
                mask: Number,
                thousandsSeparator: ' '
            }
        }

    }
    );
};