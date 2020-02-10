import React, { Component } from 'react';
export class GravitySimulation extends Component {

    componentDidMount(){
        let solarSystem = new SolarSystem;
        solarSystem.animate();
    }
    render () {
        return (
            <canvas style={{width:"100%",
        height:"100%"}} id="canvas"/>
        );
    }
}

class SolarSystem {
    x = 0;
    goingRight = true;
    animate = () => {
        

        if(this.goingRight){
            this.x += 1;
        }
        else{
            this.x -= 1;
        }

        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        ctx.fillStyle = "green";
        ctx.fillRect(this.x, 0, 100, 100);
        if(canvas.width == this.x + 100){
            this.goingRight = false;
        }
        if(this.x == 0){
            this.goingRight = true;
        }

        window.requestAnimationFrame(this.animate);
    }
}
