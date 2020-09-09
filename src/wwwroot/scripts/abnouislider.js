window.sliders = [];

window.renderSlider = function (configuration, dotNetObjectReference) {
    configuration.format = wNumb(configuration.tooltipsFormat);
    let slider = document.getElementById(configuration.id);
    noUiSlider.create(slider, configuration);
    if (configuration.generateConnectClasses) {
        var connect = slider.querySelectorAll('.noUi-connect');
        for (var i = 0; i < connect.length; i++) {
            connect[i].classList.add('c-' + i + '-color');
        }
    }
    slider.noUiSlider.on(configuration.event, function (val)
    {
        const numberFormatter = wNumb(configuration.tooltipsFormat);
        if (val.length === 1) {
            dotNetObjectReference.invokeMethodAsync("sliderValueChanged", numberFormatter.from(val[0]));
        }
        else {
            dotNetObjectReference.invokeMethodAsync("sliderValueChanged", numberFormatter.from(val[0]), numberFormatter.from(val[1]));
        }
    });
    window.sliders.push({ slider, configuration, dotNetObjectReference });
}

window.updateSlider = function (configuration) {
    window.sliders.forEach((value, index) => {
        if (value.configuration.id === configuration.id) {
            configuration.format = wNumb(configuration.tooltipsFormat);
            if (!configuration.setSlider) {
                configuration.start = value.slider.noUiSlider.get();
            }
            else if (configuration.event === "set" || configuration.event === "end" || configuration.event === "change") {
                value.slider.noUiSlider.set(configuration.start);
            }
            value.slider.noUiSlider.updateOptions(configuration);
            value.configuration = configuration; configuration.eventconfiguration.event
        }
    });
}