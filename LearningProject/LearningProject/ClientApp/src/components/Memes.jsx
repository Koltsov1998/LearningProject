import React, { Component } from 'react';
import Api from '../Utils/Api';
import { Query } from '../Utils/Query';

export class Memes extends Component {
    constructor() {
        super();
        this.state = {
            memes: []
        }
    }

    async componentDidMount(){
        var publicId = Query.GetParameterByName("publicId")
        var memes = await Api.CallForMemes(publicId)

        this.setState({
            memes: memes
        })
    }

    render () {
      return (
        <div>
            {this.state.memes.map(m => 
                <div>
                    <img src={m.url}></img>
                    <span>
                        {m.text}
                    </span>
                </div>
                )}
        </div>
      );
    }
  }
  