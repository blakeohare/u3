let renderTunnel = require('./rendertunnel.js');
const net = require('net');

const parseGameRender = data => {
    let output = [];
    let len = data.length;
    let i = 1;
    while (i < len) {
        switch (data[i]) {
            case 'F':
                if (i + 3 >= len) throw new Error("Incomplete data");
                output.push('F', parseInt(data[i + 1]), parseInt(data[i + 2]), parseInt(data[i + 3]));
                i += 4;
                break;
            
            case 'R':
                if (i + 7 >= len) throw new Error("Incomplete data");
                output.push('R');
                for (let j = 1; j <= 7; ++j) {
                    output.push(parseInt(data[i + j]));
                }
                i += 8;
                break;
            
            default:
                throw new Error("Unrecognized render command: '" + data[i] + "'");
        }
    }
    return output;
};

const run = () => {
    let tunnel = renderTunnel.createGameTunnel('My Game', 1000, 800);

    tunnel.setListener(msg => {
        console.log(msg);
    });

    let server = net.createServer(stream => {
        stream.on('data', c => {
            let dataStr = c.toString('utf8');
            let dataItems = dataStr.split(' ');
            let args;
            let commandName = dataItems[0];
            switch (commandName) {
                case 'GAME_RENDER':
                    args = parseGameRender(dataItems);
                    break;
                
                default:
                    throw new Error("Unrecognized command: " + commandName.substr(0, 100) + "...");
            }
            console.log("Data: ", c);
            tunnel.send(commandName, args);
        });

        stream.on('end', () => {
            stream.close();
        });
    });
    
    server.listen('\\\\?\\pipe\\u3pipe', () => {
        console.log("Now listenering");
    });

};

module.exports = { run };
