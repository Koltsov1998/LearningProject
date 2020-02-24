import React, { Component } from 'react';
import Api from '../Utils/Api';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';

const useStyles = makeStyles({
    inputContainer: {
        marginTop: 30,
        marginBottom: 30,
        display: 'flex',
        alignItems: 'baseline'
    },
    publicNameInput: {
        marginRight: 30,
    }
})

class Publics extends Component {
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
        const classes = this.props.classes
        return (
            <div>
                <div>
                    <div>
                        Список пабликов
                    </div>
                    <div className={classes.inputContainer}>
                        <TextField id="standard-basic" label="Ссылка на паблик" value={this.state.publicUrl} onChange={this.handleChange} className={classes.publicNameInput}/>
                        <Button onClick={this.handleSubmit}>
                            Добавить
                        </Button>
                    </div>
                </div>
                <div>
                    <TableContainer component = {Paper}>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell></TableCell>
                                    <TableCell>Название</TableCell>
                                    <TableCell>Обработано мемов</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                            {this.state.publics.map((p) =>
                                <TableRow>
                                    <TableCell>
                                        <div>
                                            <img src={p.photo50}></img>
                                        </div>
                                    </TableCell>
                                    <TableCell>
                                        <a href={p.url} target={"_blank"} >{p.name}</a>
                                    </TableCell>
                                    <TableCell>
                                        {p.postsParsed}
                                    </TableCell>
                                    <TableCell>
                                        <div>
                                            <button onClick={this.handleRemove(p.uri)}>
                                                Удалить
                                            </button>
                                        </div>
                                    </TableCell>
                                </TableRow>
                            )}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </div>
            </div>
        );
    }
}

function WithStyles(Publics){
    return function WrappedComponent(props){
        const classes = useStyles();
        return <Publics classes={classes} {...props}></Publics>
    }
}

export default WithStyles(Publics);