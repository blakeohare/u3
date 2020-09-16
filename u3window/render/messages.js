const { ipcRenderer } = require('electron');

(() => {

    ipcRenderer.on('rboundmsg', (event, data) => {
        console.log(data);
    });

    ipcRenderer.send('mboundmsg', 'hello from renderer');
})();
