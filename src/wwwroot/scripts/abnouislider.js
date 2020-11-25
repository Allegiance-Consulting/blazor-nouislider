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
    if (configuration.returnStep > 0) {
        slider.noUiSlider.on('start', function () {
            var opt = this.options;
            opt.step = opt.returnStep;
            this.updateOptions(opt, true);
        });
    }
    if (configuration.event === "slide" && configuration.manualSliderSet) {
        slider.noUiSlider.on('end', function () {
            slider.noUiSlider.set(configuration.start)
            dotNetObjectReference.invokeMethodAsync("fireEndEvent")
        });
    }
    slider.noUiSlider.on('update', function () {
        if (this.options.changeColor) {
            var tooltipColor = slider.querySelectorAll('.noUi-tooltip');
            var handleColor = slider.querySelectorAll('.noUi-horizontal .noUi-handle');
            var firstHandleOfRangeSlider = this.get([0]);
            if (firstHandleOfRangeSlider !== null && firstHandleOfRangeSlider !== undefined) {
                if (firstHandleOfRangeSlider[0] <= this.options.changeColorOnLessValue) {
                    tooltipColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                    handleColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                }
                if (firstHandleOfRangeSlider[0] > this.options.changeColorOnLessValue) {
                    tooltipColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                    handleColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                }
            }
        }
    });
    slider.noUiSlider.on(configuration.event, function (val) {
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
            //Sets the step of the slider to 1 when the 'end' event fires
            if (value.configuration.returnStep > 0) {
                value.slider.noUiSlider.on('end', function () {
                    value.configuration.step = 1;
                });
            }
            configuration.format = wNumb(configuration.tooltipsFormat);
            if (!configuration.setSlider) {
                configuration.start = value.slider.noUiSlider.get();
            }
            //else if (configuration.event === "slide" && configuration.manualSliderSet) {
            //    value.slider.noUiSlider.on('end', function () {
            //        value.slider.noUiSlider.set(configuration.start)
            //        console.log("End event hit.")
            //        dotNetObjectReference.invokeMethodAsync("fireEndEvent")
            //    });
            //}
            else if (configuration.event === "set" || configuration.event === "end" || configuration.event === "change") {
                value.slider.noUiSlider.set(configuration.start);
            }
            value.slider.noUiSlider.updateOptions(configuration);
            value.configuration = configuration; configuration.eventconfiguration.event
            //value.configuration.step = oldStep;
        }
    });
}

window.disableSliderHandle = function (sliderId) {
    let slider = document.getElementById(sliderId);
    slider.setAttribute('disabled', true);

}

window.enableSliderHandle = function (sliderId) {
    let slider = document.getElementById(sliderId);
    slider.removeAttribute('disabled');

}
