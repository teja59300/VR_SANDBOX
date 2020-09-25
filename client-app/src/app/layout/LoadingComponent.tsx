import React from 'react'
import { Dimmer, Loader } from 'semantic-ui-react'
import { observer } from 'mobx-react-lite'

 const LoadingComponent:React.FC<{inverted?:boolean,content? :string}> = ({inverted=true,content}) => {
    return (
    <Dimmer active inverted={inverted}>
                <Loader  content={content}/>
    </Dimmer>
    )
}

export default observer(LoadingComponent);
