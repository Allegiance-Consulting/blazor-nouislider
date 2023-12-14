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
    slider.noUiSlider.on('update', function () {
        var rangeSliderTooltipColor = slider.querySelectorAll('.noUi-tooltip');
        var rangeSliderHandleColor = slider.querySelectorAll('.noUi-horizontal .noUi-handle');
        var firstHandleOfRangeSlider = this.get([0]);
        var secHandleOfRangeSlider = this.get([1]);

        var singleSliderTooltipColor = slider.querySelectorAll('.noUi-tooltip')[0];
        var singleSliderHandleColor = slider.querySelectorAll('.noUi-horizontal .noUi-handle')[0];
        var singleSliderConnectColor = slider.querySelectorAll('.noUi-base')[0];
        var handleOfSlider = this.get();

        if (this.options.changeColorFirstHandleLessThen > 0) {
            if (firstHandleOfRangeSlider !== null && firstHandleOfRangeSlider !== undefined) {
                if (firstHandleOfRangeSlider[0] <= this.options.changeColorFirstHandleLessThen) {
                    rangeSliderTooltipColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                }
                if (firstHandleOfRangeSlider[0] > this.options.changeColorFirstHandleLessThen) {
                    rangeSliderTooltipColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                }
            }
        }
        if (this.options.changeColorFirstHandleBiggerThen > 0) {
            if (firstHandleOfRangeSlider !== null && firstHandleOfRangeSlider !== undefined) {
                if (firstHandleOfRangeSlider[0] >= this.options.changeColorFirstHandleBiggerThen) {
                    rangeSliderTooltipColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[0].setAttribute('style', 'background-color: ' + this.options.color);
                }
                if (firstHandleOfRangeSlider[0] < this.options.changeColorFirstHandleBiggerThen) {
                    rangeSliderTooltipColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[0].removeAttribute('style', 'background-color: ' + this.options.color);
                }
            }
        }
        if (this.options.changeColorSecHandleLessThen > 0) {
            if (secHandleOfRangeSlider !== null && secHandleOfRangeSlider !== undefined) {
                if (secHandleOfRangeSlider[1] <= this.options.changeColorSecHandleLessThen) {
                    rangeSliderTooltipColor[1].setAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[1].setAttribute('style', 'background-color: ' + this.options.color);
                }
                if (secHandleOfRangeSlider[1] > this.options.changeColorSecHandleLessThen) {
                    rangeSliderTooltipColor[1].removeAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[1].removeAttribute('style', 'background-color: ' + this.options.color);
                }
            }
        }
        if (this.options.changeColorSecHandleBiggerThen > 0) {
            if (secHandleOfRangeSlider !== null && secHandleOfRangeSlider !== undefined) {
                if (secHandleOfRangeSlider[1] >= this.options.changeColorSecHandleBiggerThen) {
                    rangeSliderTooltipColor[1].setAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[1].setAttribute('style', 'background-color: ' + this.options.color);
                }
                if (secHandleOfRangeSlider[1] < this.options.changeColorSecHandleBiggerThen) {
                    rangeSliderTooltipColor[1].removeAttribute('style', 'background-color: ' + this.options.color);
                    rangeSliderHandleColor[1].removeAttribute('style', 'background-color: ' + this.options.color);
                }
            }
        }
        if (this.options.changeColorBiggerThen > 0) {
            var sliderValue = Number(handleOfSlider.replace(this.options.tooltipsFormat.prefix, "").replace(this.options.tooltipsFormat.suffix, "").replace(/\s/g, ""));
            if (sliderValue !== null && sliderValue !== undefined) {
                if (sliderValue >= this.options.changeColorBiggerThen) {
                    singleSliderTooltipColor.setAttribute('style', 'background-color: ' + this.options.color);
                    singleSliderHandleColor.setAttribute('style', 'background-color: ' + this.options.color);
                    singleSliderConnectColor.classList.add(this.options.singleSliderConnectClass);
                }
                if (sliderValue < this.options.changeColorBiggerThen) {
                    singleSliderTooltipColor.removeAttribute('style', 'background-color: ' + this.options.color);
                    singleSliderHandleColor.removeAttribute('style', 'background-color: ' + this.options.color);
                    singleSliderConnectColor.removeAttribute('style', 'background-color: ' + this.options.color);
                    singleSliderConnectColor.classList.remove(this.options.singleSliderConnectClass);
                }
            }
        }

    });
    if (configuration.manualSliderSet) {
        slider.noUiSlider.on('end', function () {
            dotNetObjectReference.invokeMethodAsync("fireEndEvent")
        });
    }
    slider.noUiSlider.on(configuration.event, function (val) {
        const numberFormatter = wNumb(configuration.tooltipsFormat);
        if (val.length === 1) {
            var newValue = "";
            if (this.options.tooltipsFormat.suffix.includes("/")) {
                newValue = val[0].replace(this.options.tooltipsFormat.prefix, "").replace(/\/.*/, "").replace(/\s/g, "")
            }
            else {
                newValue = val[0].replace(this.options.tooltipsFormat.prefix, "").replace(this.options.tooltipsFormat.suffix, "").replace(/\s/g, "")
            }
            dotNetObjectReference.invokeMethodAsync("sliderValueChanged", numberFormatter.from(newValue));
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
                configuration.start = value.slider.noUiSlider.get().replace(configuration.tooltipsFormat.prefix, "").replace(value.configuration.tooltipsFormat.suffix, "");
            }
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
