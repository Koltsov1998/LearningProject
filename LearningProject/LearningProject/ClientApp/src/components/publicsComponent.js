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
import PlayCircleOutlineIcon from '@material-ui/icons/PlayCircleOutline';
import CircularProgress from '@material-ui/core/CircularProgress';

const useStyles = makeStyles({
    inputContainer: {
        marginTop: 30,
        marginBottom: 30,
        display: 'flex',
        alignItems: 'baseline'
    },
    playButton: {
        marginLeft: 10,
        '&:hover': {
            fill: '#46b3e6',
            cursor: 'pointer',
        }
    },
    publicNameInput: {
        marginRight: 30,
    },
    progressContainer: {
        width: 40,
        height: 40,
    },
    circleAndPercents:{
        position: "relative",
    },
    progressCircle: {
        position: 'absolute'
    },
    percentsInsideCircle: {
        position: 'absolute',
        top: 15,
        left: 5,
        fontSize: 12,
    }

})

class Publics extends Component {
    constructor(props) {
        super(props);
        this.state =
        {
            publics: [],
            publicUrl: '',
            progress: 0
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

    handleRemove = id => () => {
        Api.RemovePublic(id).then(
            this.populatePublics()
        )
    }

    handleStartProcessing = publicId => () => {
        Api.StartPhotosParsing(publicId).then(
            async () => {
                var progress = await Api.GetProgress(publicId);
                var percents = (progress.done/progress.total) *100;
                var timerId = setInterval(async() => {
                    progress = await Api.GetProgress(publicId);
                    percents = Math.round((progress.done/progress.total) *100);
                    this.setState(
                        {
                            progress: percents
                        })

                    if(percents == 100){
                        clearInterval(timerId);
                        this.populatePublics()
                    }
                    
                }, 2000)
            }
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
                                        <a href={`processedmemes?publicId=${p.id}`} target={"_blank"}>
                                            {p.postsParsed}
                                        </a>
                                        </TableCell>
                                        <TableCell>
                                        {this.state.progress == 0?<PlayCircleOutlineIcon className = {classes.playButton} onClick={this.handleStartProcessing(p.id)}></PlayCircleOutlineIcon>:
                                        <div className={classes.progressContainer}>
                                            <div className={classes.circleAndPercents}>
                                                <div className={classes.progressCircle}>
                                                    <CircularProgress variant="static" value={this.state.progress} />
                                                </div>
                                                <div className={classes.percentsInsideCircle}>
                                                    {this.state.progress}%
                                                </div>
                                            </div>
                                        </div>
                                        }
                                        
                                    </TableCell>
                                    <TableCell>
                                        <div>
                                            <button onClick={this.handleRemove(p.id)}>
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