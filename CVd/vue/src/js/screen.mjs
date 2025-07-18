import { reactive, ref } from 'vue';

export const screenSize = reactive({
    width: 0,
    height: 0
});

export const screen = ref('regular');

export function initScreen() {
    set();
    window.addEventListener('resize', handleResize)
}

export function normalizePos(pointerEvent) {
    let x = pointerEvent.clientX;
    let y = pointerEvent.clientY;

    return [x / screenSize.width, y / screenSize.height];
}

export function colorSpread(pointerEvent) {
    let list = [... pointerEvent.currentTarget.classList];
    let cat = list.find(e => e.toString().includes('category'));
    let base = categoryToBaseColor(cat);

    //oklch conversion instead of set colors?
    /*let raw = base.slice(6, -1).split(' ');
    let o = 0;

    let color = /**/

    switch (base) {
        case 'blue':
            return ['00a6fb','0582ca','006494','003554','051923'];
        case 'red':
            return ['cf263e', '734851', 'b87180', 'ceb4b8'];
        case 'green':
            return ['008209', '349e2b', '56bc47', '75da63', '93f87f'];
    }
}

export function randomInRange(min, max) {
  return Math.random() * (max - min) + min;
}


function set() {
    let rect = document.body.getBoundingClientRect();
    screenSize.width = rect.width;
    screenSize.height = rect.height;

    sizeToScreen();
    //add a breakpoint mechanic to save performance?
}

function sizeToScreen() {
    if (screenSize.width <= 1265) {
        if (screen.value != 'slim') {
            screen.value = 'slim';
            console.log('screen now considered slim');
        }
    }
    else if (screenSize.width > 1265) {
        if (screen.value != 'regular') {
            screen.value = 'regular';
            console.log('screen no longer considered slim');
        }
    }
    else {
        console.log('screen state set to unknown at ', screenSize.width, screenSize.height, screen.value);
        screen.value = 'unknown';
    }
}

function categoryToBaseColor(cat) {
    let index = cat.split('-')[1];
    switch (parseInt(index)) {
        case 1:
            return 'blue';//getCssValue('--color-blue-600');
        case 2:
            return 'red';//getCssValue('--color-red-500');
        case 3:
            return 'green';//getCssValue('--color-green-600');
    }
}

function getCssValue(identifier) {
    return window.getComputedStyle(document.body).getPropertyValue(identifier);
}

function handleResize(event) {
    set();
}