import React, { Component } from 'react';
import Api from '../Utils/Api';

export class Publics extends Component {
    constructor(props) {
        super(props);
        this.state =
        {
            publics: [],
            publicUrl: ''
        }

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    async componentDidMount() {
        this.populatePublics()  
    }

    handleChange(event) {
        this.setState({ publicUrl: event.target.value });
    }

    handleSubmit() {
        Api.AddPublicAsync(this.state.publicUrl).then(async () => {
            this.populatePublics()
        });
    }

    async populatePublics() {
        var pubs = await Api.GetAllPublicsAsync();
            this.setState({
                publics: pubs
            })
    }

    handleRemove = publicUrl => () => {
        Api.RemovePublic(publicUrl).then(
            this.populatePublics()
        )
    }

    render() {

        return (
            <div>
                <div>
                    <div>
                        Список пабликов
                    </div>
                    <div>
                        <input type="text" value={this.state.publicUrl} onChange={this.handleChange} />
                        <button onClick={this.handleSubmit}>
                            Добавить
                        </button>
                    </div>
                </div>
                <div>
                    <table>
                        {this.state.publics.map((p) =>
                            <tr>
                                <td>
                                    <a href={p.uri} >{p.uri}</a>
                                </td>
                                <td>
                                    {p.postsParsed}
                                </td>
                                <td>
                                    <div>
                                        <button onClick={this.handleRemove(p.uri)}>
                                            Удалить
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        )}
                    </table>
                </div>
            </div>
        );
    }
}