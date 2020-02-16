import React, { Component } from 'react';
export class Publics extends Component {

    componentDidMount(){
        
        fetch("localhost:5000/api/publics/getPublics").then(result => console.log(result));
    }

    render () {
        const publics = [
            {
                url: "vk.com",
                postParsed: 11
            },
            {
                url: "vk.com",
                postParsed: 11
            },
            {
                url: "vk.com",
                postParsed: 11
            }
        ]
        return (
        publics.map((p) => <div>{p.postParsed}, <a href = {p.url} >{p.url}</a></div>)
        );
    }
}