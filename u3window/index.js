const { app, BrowserWindow } = require('electron')
const { ipcMain } = require('electron')

let sendToRenderer;

function createWindow () {
  const win = new BrowserWindow({
    width: 1000,
    height: 800,
    webPreferences: {
      nodeIntegration: true
    }
  })

  sendToRenderer = msg => {
    win.webContents.send('rboundmsg', msg);
  };

  // and load the index.html of the app.
  win.loadFile('render/index.html');
}

ipcMain.on('mboundmsg', (event, arg) => {
    console.log(arg) // prints "ping"
})

setTimeout(() => {
    sendToRenderer('hello from main.');
}, 5000);

app.whenReady().then(createWindow);
